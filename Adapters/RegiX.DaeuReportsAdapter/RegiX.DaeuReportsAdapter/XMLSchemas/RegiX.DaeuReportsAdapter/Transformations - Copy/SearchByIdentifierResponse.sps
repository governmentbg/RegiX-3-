<?xml version="1.0" encoding="UTF-8"?><structure version="7" cssmode="strict" relativeto="*SPS" encodinghtml="UTF-8" encodingrtf="ISO-8859-1" encodingpdf="UTF-8" embed-images="1">	<parameters/>	<schemasources>		<namespaces>			<nspair prefix="n1" uri="http://egov.bg/RegiX/DaeuReports/SearchByIdentifierResponse"/>		</namespaces>		<schemasources>			<xsdschemasource name="$XML" main="1" schemafile="C:\Projects\RegiX\RegiX.DaeuReportsAdapter\XMLSchemas\SearchByIdentifierResponse.xsd" workingxmlfile="SearchByIdentifierResponse.xml">				<xmltablesupport/>				<textstateicons/>			</xsdschemasource>		</schemasources>	</schemasources>	<modules/>	<flags>		<scripts/>		<globalparts/>		<designfragments/>		<pagelayouts/>	</flags>	<scripts>		<script language="javascript"/>	</scripts>	<globalstyles/>	<mainparts>		<children>			<globaltemplate match="/" matchtype="named" parttype="main">				<children>					<template match="$XML" matchtype="schemasource">						<editorproperties elementstodisplay="5"/>						<children>							<template match="n1:SearchByIdentifierResponse" matchtype="schemagraphitem">								<editorproperties elementstodisplay="5"/>								<children>									<newline/>									<paragraph paragraphtag="h3">										<properties align="center"/>										<children>											<text fixtext="Държавна агенция „Електронно управление”"/>										</children>									</paragraph>									<paragraph paragraphtag="h2">										<properties align="center"/>										<children>											<text fixtext="Справка за извършвани търсения"/>										</children>									</paragraph>									<condition>										<children>											<conditionbranch xpath="n1:TotalResults = 0">												<children>													<text fixtext="Не са намерени данни за извършвани справки за подадените критерии"/>												</children>											</conditionbranch>											<conditionbranch>												<children>													<table>														<properties border="1" width="100%"/>														<styles border-collapse="collapse"/>														<children>															<tableheader>																<children>																	<tablerow>																		<children>																			<tablecell headercell="1">																				<properties align="left"/>																				<styles padding="4px"/>																			</tablecell>																			<tablecell headercell="1">																				<properties height="29"/>																				<children>																					<text fixtext="Дата"/>																				</children>																			</tablecell>																			<tablecell headercell="1">																				<properties height="29"/>																				<children>																					<text fixtext="Справка"/>																				</children>																			</tablecell>																			<tablecell headercell="1">																				<properties height="29"/>																				<children>																					<text fixtext="Правно основание"/>																				</children>																			</tablecell>																			<tablecell headercell="1">																				<properties height="29"/>																				<children>																					<text fixtext="Администрация на консуматор"/>																				</children>																			</tablecell>																			<tablecell headercell="1">																				<properties height="29"/>																				<children>																					<text fixtext="Консуматор"/>																				</children>																			</tablecell>																			<tablecell headercell="1">																				<properties height="29"/>																				<children>																					<text fixtext="Регистър/Система"/>																				</children>																			</tablecell>																			<tablecell headercell="1">																				<properties height="29"/>																				<children>																					<text fixtext="Първичен администратор"/>																				</children>																			</tablecell>																		</children>																	</tablerow>																</children>															</tableheader>															<tablebody>																<children>																	<template match="n1:ExecutedCalls" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<tablerow>																				<children>																					<tablecell>																						<styles padding="4px"/>																						<children>																							<autocalc xpath="position()"/>																						</children>																					</tablecell>																					<tablecell>																						<properties align="center"/>																						<children>																							<template match="n1:StartTime" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<content>																										<format datatype="dateTime"/>																									</content>																									<button>																										<action>																											<datepicker/>																										</action>																									</button>																								</children>																							</template>																						</children>																					</tablecell>																					<tablecell>																						<properties align="center"/>																						<children>																							<template match="n1:ReportName" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<content>																										<format datatype="string"/>																									</content>																								</children>																							</template>																						</children>																					</tablecell>																					<tablecell>																						<properties align="center"/>																						<children>																							<template match="n1:LawReason" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<content>																										<format datatype="string"/>																									</content>																								</children>																							</template>																						</children>																					</tablecell>																					<tablecell>																						<properties align="center"/>																						<children>																							<template match="n1:ConsumerAdministration" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<content>																										<format datatype="string"/>																									</content>																								</children>																							</template>																						</children>																					</tablecell>																					<tablecell>																						<properties align="center"/>																						<children>																							<template match="n1:Consumer" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<content>																										<format datatype="string"/>																									</content>																								</children>																							</template>																						</children>																					</tablecell>																					<tablecell>																						<properties align="center"/>																						<children>																							<template match="n1:Producer" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<content>																										<format datatype="string"/>																									</content>																								</children>																							</template>																						</children>																					</tablecell>																					<tablecell>																						<properties align="center"/>																						<children>																							<template match="n1:ProducerAdministration" matchtype="schemagraphitem">																								<editorproperties elementstodisplay="5"/>																								<children>																									<content>																										<format datatype="string"/>																									</content>																								</children>																							</template>																						</children>																					</tablecell>																				</children>																			</tablerow>																		</children>																	</template>																</children>															</tablebody>														</children>													</table>													<newline/>													<condition>														<children>															<conditionbranch xpath="n1:TotalResults  &gt;  n1:MaxAllowedResults">																<children>																	<text fixtext="Изобразени са първите "/>																	<template match="n1:MaxAllowedResults" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<content>																				<format datatype="int"/>																			</content>																		</children>																	</template>																	<text fixtext=" от общо "/>																	<template match="n1:TotalResults" matchtype="schemagraphitem">																		<editorproperties elementstodisplay="5"/>																		<children>																			<content>																				<format datatype="long"/>																			</content>																		</children>																	</template>																	<text fixtext=". Моля задайте по-специфични критерии!"/>																</children>															</conditionbranch>														</children>													</condition>													<newline/>												</children>											</conditionbranch>										</children>									</condition>									<newline/>									<newline/>									<newline/>								</children>							</template>						</children>					</template>				</children>			</globaltemplate>		</children>	</mainparts>	<globalparts/>	<pagelayout/>	<designfragments/></structure>