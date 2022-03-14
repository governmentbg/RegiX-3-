<?xml version="1.0" encoding="UTF-8"?><structure version="7" xsltversion="1" cssmode="strict" relativeto="*SPS" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8" embed-images="1">	<parameters/>	<schemasources>		<namespaces>			<nspair prefix="common" uri="http://egov.bg/RegiX/AV/TR/SubdeedsCommon"/>			<nspair prefix="n1" uri="http://egov.bg/RegiX/AV/TR/ActualStateResponseV3"/>		</namespaces>		<schemasources>			<xsdschemasource name="$XML" main="1" schemafile="D:\Projects\eGov\RegiX\RegiX.AVTRAdapter\XMLSchemas\TR_ActualStateResponsev3.xsd" workingxmlfile="ActualStateV3_dsk_leasing.xml">				<xmltablesupport/>				<textstateicons/>			</xsdschemasource>		</schemasources>	</schemasources>	<modules/>	<flags>		<scripts/>		<globalparts/>		<designfragments/>		<pagelayouts/>	</flags>	<scripts>		<script language="javascript"/>	</scripts>	<globalstyles/>	<mainparts>		<children>			<globaltemplate match="/" matchtype="named" parttype="main">				<children>					<template match="$XML" matchtype="schemasource">						<editorproperties elementstodisplay="5"/>						<children>							<template match="n1:ActualStateResponseV3" matchtype="schemagraphitem">								<editorproperties elementstodisplay="5"/>								<children>									<paragraph paragraphtag="h2">										<properties align="center"/>										<children>											<text fixtext="Справка за актуално състояние за вписани обстоятелства по раздели"/>										</children>									</paragraph>									<condition>										<children>											<conditionbranch xpath="n1:DataFound = &apos;true&apos;">												<children>													<template match="n1:Deed" matchtype="schemagraphitem">														<editorproperties elementstodisplay="5"/>														<children>															<template match="common:DeedStatus" matchtype="schemagraphitem">																<editorproperties elementstodisplay="5"/>																<children>																	<text fixtext="Статус на партида: "/>																	<content>																		<format datatype="string"/>																	</content>																</children>															</template>															<template match="common:CompanyName" matchtype="schemagraphitem">																<editorproperties elementstodisplay="5"/>																<children>																	<newline/>																	<text fixtext="Наименование: "/>																	<content>																		<format datatype="string"/>																	</content>																</children>															</template>															<template match="common:GUID" matchtype="schemagraphitem">																<editorproperties elementstodisplay="5"/>																<children>																	<newline/>																	<text fixtext="GUID: "/>																	<content>																		<format datatype="string"/>																	</content>																</children>															</template>															<template match="common:UIC" matchtype="schemagraphitem">																<editorproperties elementstodisplay="5"/>																<children>																	<newline/>																	<text fixtext="ЕИК: "/>																	<content>																		<format datatype="string"/>																	</content>																</children>															</template>															<template match="common:LegalForm" matchtype="schemagraphitem">																<editorproperties elementstodisplay="5"/>																<children>																	<newline/>																	<text fixtext="Правна форма: "/>																	<content>																		<format datatype="string"/>																	</content>																</children>															</template>															<template match="common:CaseNo" matchtype="schemagraphitem">																<editorproperties elementstodisplay="5"/>																<children>																	<newline/>																	<text fixtext="Решение на съда: "/>																	<content>																		<format datatype="string"/>																	</content>																</children>															</template>															<template match="common:CaseYear" matchtype="schemagraphitem">																<editorproperties elementstodisplay="5"/>																<children>																	<text fixtext="/"/>																	<content>																		<format datatype="string"/>																	</content>																</children>															</template>															<template match="common:CourtNo" matchtype="schemagraphitem">																<editorproperties elementstodisplay="5"/>																<children>																	<text fixtext="/"/>																	<content>																		<format datatype="string"/>																	</content>																</children>															</template>															<template match="common:LiquidationOrInsolvency" matchtype="schemagraphitem">																<editorproperties elementstodisplay="5"/>																<children>																	<newline/>																	<text fixtext="Ликвидация или несъстоятелност: "/>																	<content>																		<format datatype="string"/>																	</content>																</children>															</template>															<newline/>															<newline/>															<paragraph paragraphtag="h3">																<children>																	<text fixtext="Вписани обстоятелства по раздели">																		<styles font-weight="bold"/>																	</text>																</children>															</paragraph>															<template match="common:Subdeeds" matchtype="schemagraphitem">																<editorproperties elementstodisplay="5"/>																<children>																	<template match="common:Subdeed" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<template match="@SubUIC" matchtype="schemagraphitem">																				<editorproperties elementstodisplay="5"/>																				<children>																					<text fixtext="Номер на раздел/клон:">																						<styles font-weight="bold"/>																					</text>																					<text fixtext=" "/>																					<content>																						<styles font-weight="bold"/>																						<format datatype="anySimpleType"/>																					</content>																					<newline/>																				</children>																			</template>																			<template match="@SubUICType" matchtype="schemagraphitem">																				<editorproperties elementstodisplay="5"/>																				<children>																					<text fixtext="Тип на раздел: ">																						<styles font-weight="bold"/>																					</text>																					<content>																						<styles font-weight="bold"/>																						<format datatype="anySimpleType"/>																					</content>																					<newline/>																				</children>																			</template>																			<template match="@SubUICName" matchtype="schemagraphitem">																				<editorproperties elementstodisplay="5"/>																				<children>																					<text fixtext="Име на раздел/клон: ">																						<styles font-weight="bold"/>																					</text>																					<content>																						<styles font-weight="bold"/>																						<format datatype="anySimpleType"/>																					</content>																					<newline/>																				</children>																			</template>																			<template match="@SubdeedStatus" matchtype="schemagraphitem">																				<editorproperties elementstodisplay="5"/>																				<children>																					<text fixtext="Статус на раздел: ">																						<styles font-weight="bold"/>																					</text>																					<content>																						<styles font-weight="bold"/>																						<format datatype="anySimpleType"/>																					</content>																					<newline/>																				</children>																			</template>																			<newline/>																			<newline/>																			<template match="common:Records" matchtype="schemagraphitem">																				<editorproperties elementstodisplay="5"/>																				<children>																					<table>																						<properties border="0" width="100%"/>																						<children>																							<tableheader>																								<children>																									<tablerow>																										<children>																											<tablecell headercell="1">																												<properties align="left" width="297"/>																												<children>																													<text fixtext="Поле"/>																												</children>																											</tablecell>																											<tablecell headercell="1">																												<properties align="left"/>																												<children>																													<text fixtext="Стойност"/>																												</children>																											</tablecell>																										</children>																									</tablerow>																								</children>																							</tableheader>																							<tablebody>																								<children>																									<template match="common:Record" matchtype="schemagraphitem">																										<editorproperties elementstodisplay="5"/>																										<children>																											<tablerow>																												<children>																													<tablecell>																														<properties width="297"/>																														<children>																															<template match="common:MainField" matchtype="schemagraphitem">																																<editorproperties elementstodisplay="5"/>																																<children>																																	<template match="common:MainFieldCode" matchtype="schemagraphitem">																																		<editorproperties elementstodisplay="5"/>																																		<children>																																			<content>																																				<format datatype="string"/>																																			</content>																																		</children>																																	</template>																																</children>																															</template>																															<text fixtext=" - "/>																															<template match="common:MainField" matchtype="schemagraphitem">																																<editorproperties elementstodisplay="5"/>																																<children>																																	<template match="common:MainFieldName" matchtype="schemagraphitem">																																		<editorproperties elementstodisplay="5"/>																																		<children>																																			<content>																																				<format datatype="string"/>																																			</content>																																		</children>																																	</template>																																</children>																															</template>																														</children>																													</tablecell>																													<tablecell>																														<children>																															<template match="common:RecordData" matchtype="schemagraphitem">																																<editorproperties elementstodisplay="5"/>																																<children>																																	<content>																																		<format datatype="anyType"/>																																	</content>																																</children>																															</template>																														</children>																													</tablecell>																												</children>																											</tablerow>																										</children>																									</template>																								</children>																							</tablebody>																						</children>																					</table>																					<newline/>																					<newline/>																				</children>																			</template>																		</children>																	</template>																</children>															</template>															<newline/>														</children>													</template>												</children>											</conditionbranch>											<conditionbranch>												<children>													<text fixtext="В Търговския регистър не са намерени данни за търговско дружество по търсените критерии."/>													<newline/>													<newline/>												</children>											</conditionbranch>										</children>									</condition>									<template match="n1:DataValidForDate" matchtype="schemagraphitem">										<editorproperties elementstodisplay="5"/>										<children>											<text fixtext="Дата на изготвяне на справката: ">												<styles font-style="italic"/>											</text>											<content>												<styles font-style="italic"/>												<format string="DD.MM.YYYY &apos;г.&apos; hh:mm &apos;ч.&apos;" datatype="dateTime"/>											</content>										</children>									</template>								</children>							</template>						</children>					</template>				</children>			</globaltemplate>		</children>	</mainparts>	<globalparts/>	<pagelayout/>	<designfragments/></structure>