<?xml version="1.0" encoding="UTF-8"?><structure version="7" xsltversion="1" cssmode="strict" relativeto="*SPS" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8" embed-images="1">	<parameters/>	<schemasources>		<namespaces>			<nspair prefix="common" uri="http://egov.bg/RegiX/AZ"/>			<nspair prefix="n1" uri="http://egov.bg/RegiX/AZ/EmploymentProgramContractResponse"/>		</namespaces>		<schemasources>			<xsdschemasource name="$XML" main="1" schemafile="..\EmploymentProgramContractResponse.xsd" workingxmlfile="EmploymentProgramContractResponse.xml">				<xmltablesupport/>				<textstateicons/>			</xsdschemasource>		</schemasources>	</schemasources>	<modules/>	<flags>		<scripts/>		<globalparts/>		<designfragments/>		<pagelayouts/>	</flags>	<scripts>		<script language="javascript"/>	</scripts>	<globalstyles/>	<mainparts>		<children>			<globaltemplate match="/" matchtype="named" parttype="main">				<children>					<template match="$XML" matchtype="schemasource">						<editorproperties elementstodisplay="5"/>						<children>							<paragraph paragraphtag="h3">								<properties align="center"/>								<children>									<text fixtext="Агенция по заетостта"/>									<newline/>									<text fixtext="Регистър на търсещите работа лица"/>								</children>							</paragraph>							<paragraph paragraphtag="h2">								<properties align="center"/>								<children>									<text fixtext="Справка по ЕИК/БУЛСТАТ за сключен рамков договор с работодател по програма за заетост"/>								</children>							</paragraph>							<template match="n1:EmploymentProgramContractResponse" matchtype="schemagraphitem">								<editorproperties elementstodisplay="5"/>								<children>									<condition>										<children>											<conditionbranch xpath="string( . ) = &apos;&apos;">												<children>													<paragraph paragraphtag="p">														<children>															<text fixtext="Няма данни в регистъра за този ЕИК/БУЛСТАТ."/>														</children>													</paragraph>												</children>											</conditionbranch>											<conditionbranch>												<children>													<paragraph paragraphtag="p">														<children>															<text fixtext="Данни за работодател">																<styles font-weight="bold"/>															</text>														</children>													</paragraph>													<table>														<properties border="1" width="100%"/>														<children>															<tablebody>																<children>																	<tablerow>																		<children>																			<tablecell>																				<properties width="154"/>																				<children>																					<text fixtext="Идентификатор - ЕИК/БУЛСТАТ:">																						<styles font-weight="bold"/>																					</text>																				</children>																			</tablecell>																			<tablecell>																				<children>																					<template match="n1:EmployerData" matchtype="schemagraphitem">																						<editorproperties elementstodisplay="5"/>																						<children>																							<template match="common:EntityID" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<content>																										<format datatype="string"/>																									</content>																								</children>																							</template>																						</children>																					</template>																				</children>																			</tablecell>																		</children>																	</tablerow>																	<tablerow>																		<children>																			<tablecell>																				<properties width="154"/>																				<children>																					<text fixtext="Наименование на работодател:">																						<styles font-weight="bold"/>																					</text>																				</children>																			</tablecell>																			<tablecell>																				<children>																					<template match="n1:EmployerData" matchtype="schemagraphitem">																						<editorproperties elementstodisplay="5"/>																						<children>																							<template match="common:EntityName" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<content>																										<format datatype="string"/>																									</content>																								</children>																							</template>																						</children>																					</template>																				</children>																			</tablecell>																		</children>																	</tablerow>																</children>															</tablebody>														</children>													</table>													<newline/>													<condition>														<children>															<conditionbranch xpath="string ( n1:EmploymentProgramContracts ) = &apos;&apos;">																<children>																	<text fixtext="Няма данни за сключени рамкови договори по програма за заетост."/>																</children>															</conditionbranch>															<conditionbranch>																<children>																	<paragraph paragraphtag="p">																		<children>																			<text fixtext="Сключени рамкови договори по програма за заетост с работодател">																				<styles font-weight="bold"/>																			</text>																		</children>																	</paragraph>																	<template match="n1:EmploymentProgramContracts" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<template match="n1:EmploymentProgramContract" matchtype="schemagraphitem">																				<editorproperties elementstodisplay="5"/>																				<children>																					<paragraph paragraphtag="p">																						<children>																							<autocalc xpath="position()"/>																							<text fixtext=" от "/>																							<autocalc xpath="count (  ../n1:EmploymentProgramContract )"/>																							<text fixtext=": "/>																							<template match="n1:ContractNumber" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<text fixtext="Номер на договор: "/>																									<content>																										<styles text-decoration="underline"/>																										<format datatype="string"/>																									</content>																								</children>																							</template>																						</children>																					</paragraph>																					<table>																						<properties border="1"/>																						<children>																							<tablebody>																								<children>																									<tablerow>																										<children>																											<tablecell>																												<properties width="375"/>																												<children>																													<text fixtext="Наименование на програма за заетост:">																														<styles font-weight="bold"/>																													</text>																												</children>																											</tablecell>																											<tablecell>																												<children>																													<template match="n1:EmploymentProgramName" matchtype="schemagraphitem">																														<editorproperties elementstodisplay="5"/>																														<children>																															<content>																																<format datatype="string"/>																															</content>																														</children>																													</template>																												</children>																											</tablecell>																										</children>																									</tablerow>																									<tablerow>																										<children>																											<tablecell>																												<properties width="375"/>																												<children>																													<text fixtext="Дата на сключване:">																														<styles font-weight="bold"/>																													</text>																												</children>																											</tablecell>																											<tablecell>																												<children>																													<template match="n1:ContractDate" matchtype="schemagraphitem">																														<editorproperties elementstodisplay="5"/>																														<children>																															<content>																																<format string="DD.MM.YYYY" datatype="date"/>																															</content>																															<text fixtext=" г."/>																														</children>																													</template>																												</children>																											</tablecell>																										</children>																									</tablerow>																									<tablerow>																										<children>																											<tablecell>																												<properties width="375"/>																												<children>																													<text fixtext="Състояние на договор:">																														<styles font-weight="bold"/>																													</text>																												</children>																											</tablecell>																											<tablecell>																												<children>																													<template match="n1:ContractStatus" matchtype="schemagraphitem">																														<editorproperties elementstodisplay="5"/>																														<children>																															<content>																																<format datatype="string"/>																															</content>																														</children>																													</template>																												</children>																											</tablecell>																										</children>																									</tablerow>																								</children>																							</tablebody>																						</children>																					</table>																				</children>																			</template>																		</children>																	</template>																</children>															</conditionbranch>														</children>													</condition>												</children>											</conditionbranch>										</children>									</condition>								</children>							</template>						</children>					</template>				</children>			</globaltemplate>		</children>	</mainparts>	<globalparts/>	<pagelayout/>	<designfragments/></structure>