<?xml version="1.0" encoding="UTF-8"?><structure version="7" xsltversion="1" cssmode="strict" relativeto="*SPS" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8" embed-images="1">	<parameters/>	<schemasources>		<namespaces>			<nspair prefix="common" uri="http://egov.bg/RegiX/NRA/Obligations"/>			<nspair prefix="n1" uri="http://egov.bg/RegiX/NRA/Obligations/Response"/>		</namespaces>		<schemasources>			<xsdschemasource name="$XML" main="1" schemafile="D:\Projects\eGov\RegiX\RegiX.NRAObligatedPersonsAdapter\XMLSchemas\ObligatedPersonsResponse.xsd" workingxmlfile="ObligatedPersonsResponse.xml">				<xmltablesupport/>				<textstateicons/>			</xsdschemasource>		</schemasources>	</schemasources>	<modules/>	<flags>		<scripts/>		<globalparts/>		<designfragments/>		<pagelayouts/>	</flags>	<scripts>		<script language="javascript"/>	</scripts>	<globalstyles/>	<mainparts>		<children>			<globaltemplate match="/" matchtype="named" parttype="main">				<children>					<template match="$XML" matchtype="schemasource">						<editorproperties elementstodisplay="5"/>						<children>							<template match="n1:ObligationResponse" matchtype="schemagraphitem">								<editorproperties elementstodisplay="5"/>								<children>									<paragraph paragraphtag="h3">										<properties align="center"/>										<children>											<text fixtext="Национална агенция за приходите"/>											<newline/>											<text fixtext="Регистър на задължените лица"/>										</children>									</paragraph>									<paragraph paragraphtag="h2">										<properties align="center"/>										<children>											<text fixtext="Справка за наличие/липса на задължения"/>											<newline/>											<text fixtext="към дата "/>											<template match="n1:ReportDate" matchtype="schemagraphitem">												<editorproperties elementstodisplay="5"/>												<children>													<content>														<format string="DD.MM.YYYY" datatype="dateTime"/>													</content>													<text fixtext=" г."/>												</children>											</template>											<text fixtext=" "/>										</children>									</paragraph>									<condition>										<children>											<conditionbranch xpath="n1:Status/common:Code = &apos;0&apos;">												<children>													<paragraph>														<properties align="center"/>														<children>															<text fixtext="Лицето "/>															<template match="n1:Name" matchtype="schemagraphitem">																<editorproperties elementstodisplay="5"/>																<children>																	<content>																		<format datatype="string"/>																	</content>																</children>															</template>															<text fixtext=" с "/>															<template match="n1:Identity" matchtype="schemagraphitem">																<editorproperties elementstodisplay="5"/>																<children>																	<template match="common:TYPE" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<condition>																				<children>																					<conditionbranch xpath=". =&apos;EGN&apos;">																						<children>																							<text fixtext="ЕГН"/>																						</children>																					</conditionbranch>																					<conditionbranch xpath=". =&apos;Bulstat&apos;">																						<children>																							<text fixtext="БУЛСТАТ/ЕИК"/>																						</children>																					</conditionbranch>																					<conditionbranch xpath=". =&apos;LNC&apos;">																						<children>																							<text fixtext="ЛНЧ"/>																						</children>																					</conditionbranch>																					<conditionbranch xpath=".=&apos;SystemNo&apos;">																						<children>																							<text fixtext="сл. номер"/>																						</children>																					</conditionbranch>																					<conditionbranch xpath=".=&apos;BulstatCL&apos;">																						<children>																							<text fixtext="БУЛСТАТ(сл)"/>																						</children>																					</conditionbranch>																				</children>																			</condition>																		</children>																	</template>																	<template match="common:ID" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<text fixtext=" "/>																			<content>																				<format datatype="string"/>																			</content>																		</children>																	</template>																</children>															</template>															<template match="n1:ObligationStatus" matchtype="schemagraphitem">																<editorproperties elementstodisplay="5"/>																<children>																	<text fixtext=" "/>																	<condition>																		<children>																			<conditionbranch xpath=". =&apos;ABSENT&apos;">																				<children>																					<text fixtext="няма">																						<styles font-weight="bold"/>																					</text>																				</children>																			</conditionbranch>																			<conditionbranch xpath=".=&apos;PRESENT&apos;">																				<children>																					<text fixtext="има">																						<styles font-weight="bold"/>																					</text>																				</children>																			</conditionbranch>																		</children>																	</condition>																</children>															</template>															<text fixtext=" задължения към НАП"/>															<condition>																<children>																	<conditionbranch xpath="n1:Threshold &gt;0">																		<children>																			<template match="n1:Threshold" matchtype="schemagraphitem">																				<editorproperties elementstodisplay="5"/>																				<children>																					<text fixtext=" над въведния праг от "/>																					<content>																						<format datatype="unsignedShort"/>																					</content>																					<text fixtext=" лв"/>																				</children>																			</template>																		</children>																	</conditionbranch>																</children>															</condition>															<text fixtext="."/>														</children>													</paragraph>												</children>											</conditionbranch>											<conditionbranch>												<children>													<template match="n1:Status" matchtype="schemagraphitem">														<editorproperties elementstodisplay="5"/>														<children>															<text fixtext="Възникна грешка, при търсене на данни от регистъра:"/>															<newline/>															<template match="common:Code" matchtype="schemagraphitem">																<editorproperties elementstodisplay="5"/>																<children>																	<text fixtext="Код на грешка: "/>																	<condition>																		<children>																			<conditionbranch xpath=". =1">																				<children>																					<text fixtext="Невалидно XSD"/>																				</children>																			</conditionbranch>																			<conditionbranch xpath=". =&apos;2&apos;">																				<children>																					<text fixtext="Невалиден ЕИК"/>																				</children>																			</conditionbranch>																			<conditionbranch xpath=". =&apos;99&apos;">																				<children>																					<text fixtext="Друго"/>																				</children>																			</conditionbranch>																			<conditionbranch>																				<children>																					<content>																						<format datatype="int"/>																					</content>																				</children>																			</conditionbranch>																		</children>																	</condition>																</children>															</template>															<template match="common:Message" matchtype="schemagraphitem">																<editorproperties elementstodisplay="5"/>																<children>																	<newline/>																	<text fixtext="Текст на грешка: "/>																	<content>																		<format datatype="string"/>																	</content>																</children>															</template>														</children>													</template>												</children>											</conditionbranch>										</children>									</condition>								</children>							</template>						</children>					</template>				</children>			</globaltemplate>		</children>	</mainparts>	<globalparts/>	<pagelayout/>	<designfragments/></structure>